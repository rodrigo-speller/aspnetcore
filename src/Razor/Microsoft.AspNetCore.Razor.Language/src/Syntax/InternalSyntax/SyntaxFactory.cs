﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Microsoft.AspNetCore.Razor.Language.Syntax.InternalSyntax
{
    internal static partial class SyntaxFactory
    {
        internal static SyntaxToken Token(SyntaxKind kind, string content, params RazorDiagnostic[] diagnostics)
        {
            if (kind == SyntaxKind.Whitespace && diagnostics.Length == 0)
            {
                return WhitespaceTokenCache.GetToken(content);
            }

            return new SyntaxToken(kind, content, diagnostics);
        }

        internal static SyntaxToken MissingToken(SyntaxKind kind, params RazorDiagnostic[] diagnostics)
        {
            return SyntaxToken.CreateMissing(kind, diagnostics);
        }
    }
}
