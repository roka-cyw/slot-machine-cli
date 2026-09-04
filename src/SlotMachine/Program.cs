using SlotMachine.Cli;
using SlotMachine.Config;
using SlotMachine.Engine;
using SlotMachine.Views;

var slotConfigPath = Path.Combine(AppContext.BaseDirectory, "Config", "slot-config.json");
var config = GameConfigLoader.LoadFromFile(slotConfigPath);

var engine = new SlotGameEngine(
    new ScreenBuilder(),
    new WaysWinCalculator());

var options = CliOptionsParser.Parse(args);
var stops = options.StopPositions ?? new RandomStopGenerator().Generate(config);

var spinResult = engine.Spin(config, stops);

Console.WriteLine(SpinResultFormatter.Format(spinResult));