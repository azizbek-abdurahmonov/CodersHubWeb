import React from "react";

export default class RegisterPage extends React.Component{
    constructor(props){
        super(props);
        this.state={};
    }
    checkPasswd=(pwd)=>{
        var cond1=false;
        var cond2=false;
        var cond3=pwd.length>7;
        for (var x;x<pwd.length;x++) {
            if (pwd.charAt(x).toUpperCase()===pwd.charAt(x)) {cond1=true;console.log([cond1,cond2,cond3]);}
            try {
                parseInt(pwd.charAt(x));cond2=true;
            } catch (error) {
                
            }
        }
        return !([cond1,cond2,cond3].includes(false))
    }
    register=()=>{
        var fname=document.getElementById("firstName").value;
        if (fname.length<3){
            alert("Firstname must include at least 3 characters.")
            return;
        }
        fname=`FirstName=${fname}`;
        var lname=document.getElementById("lastName").value;
        if (lname.length>0) lname=`&LastName=${lname}`
        var bio=document.getElementById("bio").value;
        if (bio.length>0) bio=`&Bio=${bio}`
        else bio=`&Bio=Not Given`
        var email=document.getElementById("email").value;
        if ([email.includes('@'), email.slice(email.indexOf('@')).includes('.'), !(email.endsWith('.'))].includes(false)) {alert("Invalid Email");return;}
        email=`&EmailAddress=${email}`;
        var passwd=document.getElementById("password").value;
        if (passwd.length<9) {alert("Password is not strong");return;}
        passwd=`&Password=${passwd}`;
        fetch(
            encodeURI(`http://localhost:5295/api/Registration/Register?${fname}${lname}${bio}${email}${passwd}`),{
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
                alert("Error")
                res.text().then((data)=>{
                    console.log(data);
                })
            }
        })
    }
    render(){
        if (sessionStorage.getItem("userToken")!==null) {window.open('/','_self');return(<></>)}
        return(
            <div style={{display: "flex",flexDirection: "column",alignItems: "center",marginTop: "15%"}}>
                <div style={{display: "flex",flexDirection: 'row',justifyContent: 'space-between',marginBottom: "5px",width: '60%'}}>
                    <input type="text" style={{width: "49.5%"}} id="firstName" placeholder="First name"/> <input type="text" style={{width: "49.5%"}} id="lastName" placeholder="Last name"/>
                </div><br/>
                <input type="email" id="email" style={{width: "60%",marginBottom: "5px"}} placeholder="Email"/><br/><br/>
                <input type="password" id="password" style={{width: "60%",marginBottom: "5px"}} placeholder="Password"/><br/><br/>
                <textarea id="bio" style={{width:"60%",height: "120px",marginBottom: "5px"}} placeholder="Write something about you..."></textarea>
                <a href="/login" style={{marginBottom: "15px"}}>Already have account? Go to login page</a>

                <button style={{width: "40%"}} onClick={()=>this.register()}>Register</button><br/>
                
            </div>
        )
    }
}