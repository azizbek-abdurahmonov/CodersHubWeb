'use client'

import React from "react";
import Auth from "../auth";
import { useParams } from "react-router-dom";

class Blog extends React.Component{
    constructor(props){
        super(props);
        this.state={firstName:"",post:{}};
        this.auth=new Auth(sessionStorage.getItem("userToken"));
        console.log(this.props);
    }
    load=()=>{
        if (this.state.firstName=="") {
        this.auth.checkUser().then((res)=>{
            if (res.status==200) {
                res.json().then((data)=>{
                    if (this.state.firstName=="") {this.setState({firstName: data.firstName})};
                })
                fetch("http://localhost:5295/api/BlogPost/GetById?id="+this.props.params.blogId,{
                    headers: new Headers({
                        'accept':'text/plain',
                        "Access-Control-Allow-Origin": "*"
                    })
                }).then((res2)=>{
                    res2.json().then((data2)=>{
                        this.setState({post:data2})
                    })
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
                    <h1 style={{margin: 0,padding:0}}>{this.state.post.title} </h1>
                    <p>{this.state.post.createdDate}</p><br/>
                    <p>{this.state.post.body}</p>
                </>
        )
    }
}

export default function BlogPage(){
    var params=useParams();
    return (
        <Blog params={params}/>
    );
}