'use client'

import React from "react";
import Auth from "../auth";

export default class CreatePost extends React.Component{
    constructor(props){
        super(props);
        this.state={firstName:""};
        this.auth=new Auth(sessionStorage.getItem("userToken"));
    }
    create=()=>{
        var title=document.getElementById("title").value;
        var body=document.getElementById("body").value;
        if (body.length<5||title.length<5){alert("Your post is too small");return;}
        fetch("http://localhost:5295/api/BlogPost/Add?token="+sessionStorage.getItem("userToken"),{
        method: "POST",    
        headers: new Headers({
                'accept':'text/plain',
                'Content-Type': 'application/json',
                "Access-Control-Allow-Origin": "*"
            }),
            body: JSON.stringify({
                body: body,
                title: title
            })
        }).then((res)=>{
            if (res.status==200) {
                window.open('/','_self')
            } else {
                console.log(res);
                alert("error")
            }
        });
    }
    load=()=>{
        if (this.state.firstName=="") {
        this.auth.checkUser().then((res)=>{
            if (res.status==200) {
                res.json().then((data)=>{
                    if (this.state.firstName=="") {this.setState({firstName: data.firstName})};
                })
            }else{
                sessionStorage.clear();
                window.open("/login","_self");
            }
        })}
    }
    render(){
        this.load();
        return (
                <>
                    <input id="title" placeholder="Enter title" style={{width: "80%",}}/><br/>
                    <textarea id="body" placeholder="Enter body" style={{width: "80%",height: "50%"}}></textarea><br/><br/>
                    <button style={{width: "80%"}} onClick={this.create}>Post</button>
                </>
        )
    }
}