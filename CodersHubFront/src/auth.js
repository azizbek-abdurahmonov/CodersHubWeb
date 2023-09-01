export default class Auth{
    constructor(token){
        this.token=token;
    }
    validToken=false;
    checkUser(){
        return fetch('http://localhost:5295/api/User/GetUser?token='+this.token,{
            method: 'GET',
            headers: new Headers({
                'accept':'text/plain',
                "Access-Control-Allow-Origin": "*"
            })
        })
        // .then((res)=>{
        //     if (res.status==200) {
        //         console.log("correct");
        //         this.validToken=true;
        //     }else this.validToken=true;
        //     res.text().then((data)=>console.log(data))
        //     return "end"
        // }).catch((e)=>console.log(e))
    }
}