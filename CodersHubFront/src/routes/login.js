import React from "react";

export default class LoginPage extends React.Component{
    constructor(props){
        super(props);
        this.state={};
    }
    login=()=>{
        var email=document.getElementById("email").value;
        if ([email.includes('@'), email.slice(email.indexOf('@')).includes('.'), !(email.endsWith('.'))].includes(false)) {alert("Invalid Email");return;}
        email=`EmailAddress=${email}`;
        var passwd=document.getElementById("password").value;
        if (passwd.length<9) {alert("Password is not strong");return;}
        passwd=`&Password=${passwd}`
        fetch(
            encodeURI(`http://localhost:5295/api/Registration/Login?${email}${passwd}`),{
                method: 'POST',
                mode: 'cors',
                headers: new Headers({
                    'accept':'text/plain'
                })
            }
        ).then((res)=>{
            console.log(res);
            if (res.status==200){
                res.json().then((data)=>{
                    sessionStorage.setItem("userToken",data);
                    window.open('/','_self')
                })
            }else{
                alert("Email or password is incorrect")
            }
        })
    }
    render(){
        if (sessionStorage.getItem("userToken")!==null) {window.open('/','_self');return(<></>)}
        return(
            <div onLoadStart={()=>this.checkSession()} style={{display: "flex",flexDirection: "column",alignItems: "center",marginTop: "20%"}}>
                <input type="email" id="email" style={{width: "60%",marginBottom: "5px"}} placeholder="Email"/><br/><br/>
                <input type="password" id="password" style={{width: "60%",marginBottom: "5px"}} placeholder="Password"/><br/><br/>
                <a href="/register" style={{marginBottom: "15px"}}>You don't have account? Go to register page</a>
                <button style={{width: "40%"}} onClick={()=>this.login()}>Login</button>
            </div>
        )
    }
}