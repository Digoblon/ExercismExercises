public class SecurityPassMaker
{
    public string GetDisplayName(TeamSupport support)
    {
        try
       {
            object o = support;
            //o is Staff;
            if(o is Staff stf)
            {
                if(o.GetType() == typeof(Security))
                {
                    return $"{stf.Title} Priority Personnel";
                }
                else
                {
                    return stf.Title;
                }
            }
            else
            {
                return "Too Important for a Security Pass";
            }
        }
            catch (InvalidCastException e)
            {
                return e.Message;
            }
                
    }
}

/**** Please do not alter the code below ****/

public interface TeamSupport { string Title { get; } }

public abstract class Staff : TeamSupport { public abstract string Title { get; } }

public class Manager : TeamSupport { public string Title { get; } = "The Manager"; }

public class Chairman : TeamSupport { public string Title { get; } = "The Chairman"; }

public class Physio : Staff { public override string Title { get; } = "The Physio"; }

public class OffensiveCoach : Staff { public override string Title { get; } = "Offensive Coach"; }

public class GoalKeepingCoach : Staff { public override string Title { get; } = "Goal Keeping Coach"; }

public class Security : Staff { public override string Title { get; } = "Security Team Member"; }

public class SecurityJunior : Security { public override string Title { get; } = "Security Junior"; }

public class SecurityIntern : Security { public override string Title { get; } = "Security Intern"; }

public class PoliceLiaison : Security { public override string Title { get; } = "Police Liaison Officer"; }
