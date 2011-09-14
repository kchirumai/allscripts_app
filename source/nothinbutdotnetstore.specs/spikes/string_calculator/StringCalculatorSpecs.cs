using System;
using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;

namespace nothinbutdotnetstore.specs.spikes.string_calculator
{
    [Subject(typeof(StringCalculator))]
    public class StringCalculatorSpecs
    {
        public abstract class concern : Observes<StringCalculator>
        {
        }

        public class when_adding_string_of_numbers : concern
        {
            static int result;

            //Act
            Because b = () =>
                result =new StringCalculator().add_strings("");
            
            It should_return_the_sum = () =>
                result.ShouldEqual(0);
        }
    }

    public class StringCalculator
    {
        public int add_strings(string numbers)
        {
            int result = 0;
            
            if (string.IsNullOrEmpty(numbers)) return result;

            foreach (string arg in numbers.Split(','))
            {
                result = result + Convert.ToInt32(arg.Trim());
            }

            return result;
        }
    }
}