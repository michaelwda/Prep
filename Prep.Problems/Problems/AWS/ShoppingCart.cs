using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prep.Problems.Problems.AWS
{
    public class ShoppingCart
    {
        public int Solve(List<List<string>> codeList, List<string> shoppingCart)
        {
            if (codeList == null || !codeList.Any() || (codeList.Count == 1 && !codeList[0].Any()))
                return 1;

            var groupPosition = 0;
            var itemPosition = 0;
            for (var itemIndex = 0; itemIndex < shoppingCart.Count; itemIndex++)
            {
                var item = shoppingCart[itemIndex];
                if (codeList[groupPosition][itemPosition] == item)
                {
                    itemPosition++;
                }
                else if (codeList[groupPosition][itemPosition] == "anything") 
                {
                    if (itemPosition == 0)
                    {
                        //we've matched this forever now
                        codeList[groupPosition].RemoveAt(0);
                    }
                    else
                    {
                        itemPosition++;
                    }
                }
                else
                {
                    //failure, reset
                    itemPosition = 0;
                }

                if (itemPosition >= codeList[groupPosition].Count)
                {
                    groupPosition++;
                    itemPosition = 0;
                }

                if (groupPosition >= codeList.Count)
                {
                    return 1;
                }
            }


            return 0;
        }
    }

    public class ShoppingCartFSM
    {
        public int Solve(List<List<string>> codeList, List<string> shoppingCart)
        {
            if (codeList == null || !codeList.Any() || (codeList.Count == 1 && !codeList[0].Any()))
                return 1;

             //Build state-machine
             var sm = new CodeStateMachine(codeList);

             foreach (var item in shoppingCart)
             {
                 sm.Input(item);
                 if (sm.Finished)
                     return 1;
            }

            return 0;
        }
    }

    public class CodeStateMachine
    {
        private State _current=null;
        public CodeStateMachine(List<List<string>> codeList)
        {
            State lastState = null;
            foreach (var codes in codeList)
            {
                State mostRecentNonWildcard = null;
               
                foreach (var code in codes)
                {
                    State state = null;
                    if (code == "anything")
                    {
                        state=new WildCardState();
                    }
                    else
                    {
                        var fruitState = new FruitState(code);
                        if (mostRecentNonWildcard == null)
                        {
                            mostRecentNonWildcard = fruitState;
                        }

                        //point failure condition to fall back to most recent non wildcard
                        fruitState.Fail = mostRecentNonWildcard;

                        //Update the most recent nonwildcard to be this one
                        mostRecentNonWildcard = fruitState;

                        state = fruitState;
                    }

                    if (lastState == null)
                    {
                        lastState = state;
                        if(_current==null)
                            _current = state;
                    }
                    else
                    {
                        lastState.SetNext(state);
                        lastState = state;
                    }
                }

            }
        }

        internal interface State
        {
            void SetNext(State state);
            State GetNext(string value);
        }
      

        //Wildcard will always progress to the next state
        internal class WildCardState : State
        {
            public State Next;

            public void SetNext(State state)
            {
                Next = state;
            }
            public State GetNext(string value)
            {
                return Next;
            }
        }

        internal class FruitState : State
        {
            public State Next;
            public State Fail;
            private readonly string _match;

            public FruitState(string match)
            {
                _match = match;
            }
            public void SetNext(State state)
            {
                Next = state;
            }
            public State GetNext(string value)
            {
                return value == _match ? Next : Fail;
            }
        }

        public bool Finished { get; set; }

        public void Input(string item)
        {
            if (Finished)
                return;
            
            _current = _current.GetNext(item);

            if (_current == null)
                Finished = true;
        }
    }


}
