'use client'

import React from "react";
import Auth from "../auth";
import Article from "../components/article";

export default class Home extends React.Component{
    constructor(props){
        super(props);
        this.state={firstName:"",posts: []};
        this.auth=new Auth(sessionStorage.getItem("userToken"));
        
    }
    load=()=>{
        if (this.state.firstName=="") {
        this.auth.checkUser().then((res)=>{
            if (res.status==200) {
                res.json().then((data)=>{
                    if (this.state.firstName=="") {this.setState({firstName: data.firstName})};
                })
                fetch("http://localhost:5295/api/BlogPost/GetAllPosts",{
                            headers: new Headers({
                                'accept':'text/plain',
                                "Access-Control-Allow-Origin": "*"
                            })
                }).then((res2)=>{
                    res2.json().then((data2)=>{
                        data2.reverse();
                        this.setState({posts: data2.slice(0,4)})
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
                    <h1>Hi, {this.state.firstName}.</h1>
                    <p>Welcome back! Explore CodersHub from here...</p>
                    <section className="articles">
                        {this.state.posts.map((e)=>{
                            return (
                                <Article
                                ket={e.id}
                                post_id={e.id}
                                title={e.title}
                                body={e.body}
                                />
                            )
                        })}
                    </section>
                </>
        )
    }
}