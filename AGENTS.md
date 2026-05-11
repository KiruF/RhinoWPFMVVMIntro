# Repository Guidelines

## Project Structure & Module Organization

- `Views/` and `ViewModels/` are reserved for WPF MVVM UI and view models.

## Coding Style & Naming Conventions

- C# formatting: 4-space indentation, braces on the next line, one type per file.
- Classes use PascalCase (e.g., `SupporterPlugin`).
- Prefer explicit access modifiers and XML doc comments for public APIs.
- Do not explicitly use the private keyword for methods, fields, or properties. Rely on the default access level instead.
int _count;
void Calculate()
{
    // implementation
}
- For properties and methods using expression-bodied syntax, place the => operator on a new line. This rule applies consistently to all expression-bodied members.
public int Count
    => _count;
In linq expressions the => operator should be placed on the same line, but each pipeline call, should be on a separate line
List<Line> relevantOrderedLines = boxes    
    .Where(box => box.Diagonal.Length > 0)
    .SelectMany(box => box.Edges
        .OrderBy(e => e.Mid.X))
    .OrderBy(l => l.Length)
    .ToList();    
- Do not use braces { } for single-line method bodies or control statements.
if (isReady)
    Start();
- Follow the above rules consistently across the entire codebase. Prefer readability and uniform formatting over compactness.

No formatter or linter is configured; keep changes consistent with existing style.

## Style

- Stay continuous, but make every clause earn its tokens.
- Drop helper verbs, articles, and filler aggressively when meaning survives.
- Prefer topic: details; next topic: details over full sentences.
- Collapse repeated subjects and shared context.
- Shorten obvious action words when safe: auth, ops, docs, migrate, revert, compat, env, cfg.
- Prefer compact noun/action phrases over explicit predicate wording.
- Avoid one-fact-per-line or rigid schemas.
- Don't write defensive code inside hot inner loops when all of the data is already validated when the object enters the data structure.