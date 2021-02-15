# MMT Shop Client

## Implementation

The approach taken for the menu interface, for this application, 
uses a simple version of the command dispatcher pattern, 
taken from one of my own projects and slightly tweaked.

[Mediatr](https://github.com/jbogard/MediatR) could have been used for this 
however due to the rich features available in Mediatr, I felt it was a 
bit over-kill for a simple console application.it would not harness the full range of features Mediatr offers 
(such as pipelines behaviours, etc.), whereas the Server application was a perfect 
candidate for Mediatr.

When I started implementing the client, I used a simple dictionary object to 
manage the interaction for menu items. 

However this would pose a few issues, firstly unit testing a dictionary
is very difficult and secondly it caused Program.cs to instantiate
a set of modules it did not necessarily care about 
(CategoryModule, ProductModule). The displaying of the menu and accepting user 
input is the only concern Program.cs should have to contend with.

### Command Dispatcher Pattern

The [command dispatcher](https://olvlvl.com/2018-04-command-dispatcher-pattern) 
uses dependency injection to instantiate the necessary handler it needs to 
fullfill a specific command.

MMTShop.Shared contains the base implementation (service resolution) for the
MenuCommandDispatcher which invokes a specific type of IDispatcherHandler based 
on the command that was inputted (1,2 q). This is to enable future dispatchers
to be easily implemented.

In the case of the MenuCommandDispatcher, the dispatcher recieves a character 
(char) input from the end-user and using the internal DispatcherDictionary it 
determines which DispatchHandler should be resolved and invoked.

To add additional menu options the additional handlers and associated modules 
will need to be created/updated under the specific features they implement then 
the internal DispatcherDictionary will need to be updated to include the necessary 
command required to invoke them.

The handlers and modules will automatically be available to the built-in 
dependency injection container via the [Scrutor](https://github.com/khellang/Scrutor) 
implementation.