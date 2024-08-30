const express = require('express');
const AccountModel = require('./model/AccountModel.js');
const app = express();

app.get('/',(req,res)=>{
    console.log(req.query);
    let name = '';
    let age = 0;
    let pgskill = '';
    switch(req.query.Name)
    {
        case "SUHAN":
            name = "SUHAN";
            age = 27;
            pgskill = "C#";
            break;
        case "NJK":
            name = "NJK";
            age = 27,
            pgskill = "javascript";
            break;
    }
    const account = new AccountModel(name,age,pgskill);
    console.log(account.displayName);
    res.json(account);
});

app.listen(7777, () =>{ 
    console.log("listen!");
});