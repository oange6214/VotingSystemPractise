ICounter yes = new Counter("Yes", 4);
ICounter no = new Counter("No", 4);
ICounter maybe = new Counter("Maybe", 4);
ICounter hopeuflly = new Counter("hopeuflly", 4);

var manager = new CounterManager(yes, no, maybe, hopeuflly);

manager.AnounceWinner();