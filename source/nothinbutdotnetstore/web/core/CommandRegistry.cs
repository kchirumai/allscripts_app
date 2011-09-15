using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.core
{
    public class CommandRegistry : ICanFindCommands
    {
        IEnumerable<IProcessARequest> all_commands;
        IProcessARequest the_special_case;

        public CommandRegistry(IEnumerable<IProcessARequest> all_commands, IProcessARequest the_special_case)
        {
            this.all_commands = all_commands;
            this.the_special_case = the_special_case;
        }

        public IProcessARequest get_the_command_that_can_process(IContainRequestInformation the_request)
        {

            return all_commands.FirstOrDefault(x => x.can_handle(the_request))?? the_special_case;

        }
    }
}