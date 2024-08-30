var express = require('express');

const app = express();
app.use(express.urlencoded({extended : true}));

app.get('/', (req,res) =>{
    console.log("Get Request");
    console.log(req.query);
    const var1 = parseInt(req.query.var1,10);
    const var2 = parseInt(req.query.var2,10);
    res.send(`result : ${var1+var2}`);
});

app.post('/',(req,res)=>{
    var postData = req.body;
    console.log(`postData : ${postData}`);
    res.send("Post Accepted!!");
})
app.listen(7777,()=>{
    console.log('listening!!');
})
