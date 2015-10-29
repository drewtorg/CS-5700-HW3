I chose to create an application for creating pokemon themed images.

I did so using C# WinForms.  I employed the Singleton, Factory, Flyweight, Command, and Undo patterns in my code.
The Singletons and Flyweights can be seen in my PokemonModel class.  Each of the classes inheriting from the PokemonModel is a Singleton.
The model is then passed to a corresponding Pokemon class as its intrinsic state.  The only state it holds onto is a Bitmap Image.
The reasoning behind this is avoid having many copies of the Images in memory, when just one is more than enough to share.
Factories are seen in the CommandFactory, PokemonFactory, and PokemonModelFactory classes which are only used to create objects of
the corresponing types.  The Drawing class also has two facotry methods which are useful in keeping the messy canvas creation to
just the Drawing class.  The Command and Undo patterns are seen quite obviously in the Command class heirarchy.  Each Command
type of Command class has an overrided Execute and Undo method.  Both the Invoker and Receiver in this case is the Drawing class.

The extra credit I chose to implement was that of allowing the user to create more sophisticated backgrounds.  The user actually
has the ability to use a simple background color or chose to use one of several stock images fom the pokemon world.  It required
quite a bit more effort, but really makes the project that much more entertaining.

