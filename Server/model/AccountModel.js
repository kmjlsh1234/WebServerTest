class AccountModel
{
    constructor(displayName, age, ProgrammingSkill)
    {
        this.DisplayName = displayName;
        this.Age = age;
        this.ProgrammingSkill = ProgrammingSkill;
    }

    GetAccountInfo()
    {
        return this;
    }
    
}

module.exports = AccountModel;