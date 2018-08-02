﻿using System;
using System.Collections.Generic;
using static MoonSharp.TokenType;

namespace MoonSharp {
    class Lexer {
        private readonly string source;
        private readonly List<Token> tokens = new List<Token>();

        private int start, current;
        private int line = 1;

        public Lexer(string source) => this.source = source;

        public List<Token> Tokenize() {
            while(current < source.Length) {
                start = current;
                ScanToken();
            }
            return tokens;
        }

        private void ScanToken() {
            var c = source[current++];

            switch(c) {
                case '(': AddToken(LeftParen); break;
                case ')': AddToken(RightParen); break;
                case '{': AddToken(LeftBracket); break;
                case '}': AddToken(RightBracket); break;
                case ',': AddToken(Comma); break;
                case '.': AddToken(Dot); break;
                case ';': AddToken(Semicolon); break;
                case ':': AddToken(Colon); break;
                case '+': AddToken(Plus); break;
                case '-': AddToken(Minus); break;
                case '*': AddToken(Star); break;

                case '=':
                    AddToken(IsMatching('=') ? EqualEqual : Equal);
                    break;
                case '!':
                    AddToken(IsMatching('=') ? BangEqual : Bang);
                    break;
                case '<':
                    AddToken(IsMatching('<') ? LessEqual : Less);
                    break;
                case '>':
                    AddToken(IsMatching('>') ? GreaterEqual : Greater);
                    break;

                case '/':
                    if(!IsMatching('/')) {
                        AddToken(Slash);
                        break;
                    }
                    // Ignore one-line comments
                    while(current < source.Length && source[current] != '\n') {
                        current++;
                    }
                    break;

                case '"':
                    TryString();
                    break;

                // Ignore whitespace
                case '\r':
                case '\t':
                case ' ':
                    break;

                case '\n':
                    line++;
                    break;

                default:
                    Moon.GenerateError(line, "Unexpected character.");
                    break;
            }
        }

        

        private void AddToken(TokenType type, string lexame = null) {
            var lex = lexame ?? source.Substring(start, current - start);
            var token = new Token(type, lex, line);
            tokens.Add(token);
        }

        private void TryString() {
            while(!IsAtEnd() && source[current] != '\n' && source[current] != '"') {
                current++;
            }

            if(!IsAtEnd() && source[current] == '"') {
                current++;
                var lexame = source.Substring(start, current - start);
                AddToken(StringToken, lexame);
                return;
            }

            Moon.GenerateError(line, "String does not have closing \"");
        }

        private bool IsAtEnd() => current >= source.Length;

        private bool IsMatching(char expected) {
            if(current >= source.Length) {
                return false;
            }

            if(source[current] != expected) {
                return false;
            }

            current++;
            return true;
        }
    }
}
