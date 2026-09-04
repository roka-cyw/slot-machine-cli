# Slot Machine CLI

## Overview

A C#/.NET command line slot machine implementation with a small engine-focused structure. The project covers configurable reel bands, visible screen generation, random and fixed stop positions, ways win calculation, formatted console output, and unit tests for the core slot logic.

## Tech Stack

- C#/.NET
- xUnit

## Run the project

- Random spin - `dotnet run --project src/SlotMachine`
- Spin with stop positions - `dotnet run --project src/SlotMachine -- --stops 0 11 1 10 14`

## Requirements

- 5x3 slot screen generated from reel bands
- Random stop positions are selected from valid reel ranges
- Fixed stop positions can be provided through CLI arguments
- Visible screen symbols are displayed in console 
- Reel bands wrap around when stop positions are near the end 
- Ways wins are calculated left to right from the 1st column
- Ways wins pay for configured 3, 4 and 5 of a kind
- Output displays total win and ways win details 
- Win details include screen positions, symbol id, match count, and payout

## Architecture

The project uses an MVC-inspired architecture with an isolated slot engine:

- `Config` loads the game configuration from JSON: visible rows, reel bands, and paytable
- `Models` stores slot data such as screen, win entries, and spin result
- `Engine` contains the non-console slot logic: screen generation, random stop generation, and ways win calculation
- `Cli` parses command-line arguments such as `--stops`
- `Views` formats the spin result for console output
- `Program.cs` wires the app together and stays as a thin entry point

## Slot logic

- The visible screen is generated from reel stop positions. Each reel uses its configured reel band and wraps around when the stop position is near the end of the band
- Ways wins are evaluated from the first column only
- Matching symbols must appear on consecutive columns from left to right
- Multiple matching symbols in a column create multiple ways
- Payouts are read from the configured paytable

## Tests

xUnit tests cover:

- Screen generation from stop positions
- Reel band wrap-around
- Invalid stop position count
- Stop positions outside reel band range
- All provided cases (win or non-win)
- Ways wins starting from the first column only
- CLI argument parsing

## Final Check

### Run tests

- Run all tests - `dotnet test`
- Run random spin - `dotnet run --project src/SlotMachine`
- Run spin with specific stop positions - `dotnet run --project src/SlotMachine -- --stops 0 11 1 10 14`
- Run specific file with tests (only tests for ways for example) - `dotnet test --filter WaysWinCalculatorTests`

