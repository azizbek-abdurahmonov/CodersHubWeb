'use client'



import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React from "react";
import ModalComponent from "../components/ModalComponent";
import { Avatar } from "@mui/material";
import Auth from "../auth";
import Article from "../components/article";

export default class ProfilePage extends React.Component{
    constructor(props){
        super(props);
        this.auth=new Auth(sessionStorage.getItem("userToken"));
        this.state={user: {
            token: "",
            firstName: "",
            lastName: "",
            emailAddress: "",
            bio: ""
        },posts: []};
    }
    editDetails=()=>{
        var fname=document.getElementById("firstName").value;
        if (fname.length<3){
            alert("Firstname must include at least 3 characters.")
            return;
        }
        var cpasswd=document.getElementById("currentPassword").value;
        if (cpasswd=="") {cpasswd=this.state.user.password}
        if (cpasswd.length<9) {alert("Password is not strong");return;}
        var lname=document.getElementById("lastName").value;
        if (lname.length>0) 
        var bio=document.getElementById("bio").value;
        if (bio.length==0) bio=`&Bio=Not Given`
        var email=document.getElementById("email").value;
        if ([email.includes('@'), email.slice(email.indexOf('@')).includes('.'), !(email.endsWith('.'))].includes(false)) {alert("Invalid Email");return;}
        var npasswd=document.getElementById("newPassword").value;
        if (npasswd=="") {npasswd=this.state.user.password}
        if (npasswd.length<9) {alert("Password is not strong");return;}
        fetch("http://localhost:5295/api/User/UpdateUser?token="+this.state.user.token+"&currentPassword="+cpasswd,{
            method: "POST",
            headers: new Headers({
                'accept': '*/*',
                'Content-Type':'application/json',
                "Access-Control-Allow-Origin": "*"
            }),
            body:JSON.stringify({
                firstName: fname,
                lastName: lname,
                bio: bio,
                emailAddress: email,
                password: npasswd
              })
        }).then((res)=>{
            if (res.status==200){
                window.open('/profile','_self');
            }else{
                console.log(res);
            }
        });
    }
    load=()=>{
        if (this.state.user.firstName=="") {
            this.auth.checkUser().then((res)=>{
                if (res.status==200) {
                    res.json().then((data)=>{
                        console.log(this.state.user);
                        if (this.state.user.firstName=="") {this.setState({user: data})};
                        fetch("http://localhost:5295/api/BlogPost/GetUserPosts?token="+data.token,{
                            headers: new Headers({
                                'accept':'text/plain',
                                "Access-Control-Allow-Origin": "*"
                            })
                        }).then((resPosts)=>{
                            if (resPosts.status==200){
                                resPosts.json().then(dataPosts=>{
                                    dataPosts.reverse()
                                    this.setState({posts: dataPosts});  
                                })
                            }
                        })
                    })
                }else{
                    sessionStorage.clear();
                    window.open("/login","_self");
                }
            })
        }
    }
    EditModalContent=()=>{
        return(
            <>
            <h1>Edit profile</h1>
            <hr/>
            <input type="email" id="email" style={{width: "100%"}} placeholder="Email" defaultValue={this.state.user.emailAddress}/><br/><br/>
            <div style={{display: "flex",flexDirection: 'row',justifyContent: 'space-between'}}>
                <input type="text" style={{width: "45%"}} id="firstName" placeholder="First name" defaultValue={this.state.user.firstName}/> <input type="text" style={{width: "45%"}} id="lastName" placeholder="Last name" defaultValue={this.state.user.lastName}/>
            </div><br/>
            <div style={{display: "flex",flexDirection: 'row',justifyContent: 'space-between'}}>
                <input type="password" style={{width: "45%"}} id="currentPassword" placeholder="Current password"/> <input type="password" style={{width: "45%"}} id="newPassword" placeholder="New password"/>
            </div><br/>
            <textarea style={{width:"100%",height: "120px"}} id="bio" placeholder="Write something about you..." defaultValue={this.state.user.bio}></textarea>
            </>
        )
    }
    render(){
        this.load();
        return (
            <div id="profile">
                <div id="profileInfo">
                    <Avatar sx={{ width: 150, height: 170 }} variant="rounded" style={{fontSize: "72px",marginRight: "20px"}}>{this.state.user.firstName.charAt(0)}</Avatar>
                    <div>
                        <h1>{this.state.user.firstName} {this.state.user.lastName}</h1>
                        <p>{this.state.user.bio}</p>
                        <div style={{paddingRight: "20px"}}>
                            <ModalComponent 
                            buttonChild={<><FontAwesomeIcon icon="fa-solid fa-pencil"/> Edit</>}
                            modalContent={<><this.EditModalContent/></>}
                            compButtonText="Save"
                            handleCompButton={this.editDetails}
                            />
                            {/* <button onClick={()=>{navigator.clipboard.writeText("https://localhost:3000/profile/endie");alert("Copied to clipboard")}}>Share</button> */}
                        </div>
                    </div>
                </div>
                <hr/>
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
            </div>
        )
    }
}