import React from "react";
import './explore-posts.css';

export default class Article extends React.Component{
    constructor(props){
        super(props);
        this.state={};
    }
    render(){
        return (
            <article>
                <div className="article-wrapper">
                <figure>
                    <img src="https://img.freepik.com/premium-photo/opened-book-with-flying-pages-butterflies-dark-backgroundgenerative-ai_391052-12859.jpg" alt="" />
                </figure>
                <div className="article-body">
                    <h2>{this.props.title}</h2>
                    <p>
                    {this.props.body.slice(0,50)}
                    </p>
                    <a href={"/blogs/"+this.props.post_id} className="read-more">
                    Read more <span className="sr-only">about this is some title</span>
                    <svg xmlns="http://www.w3.org/2000/svg" className="icon" viewBox="0 0 20 20" fill="currentColor">
                        <path fillRule="evenodd" d="M12.293 5.293a1 1 0 011.414 0l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414-1.414L14.586 11H3a1 1 0 110-2h11.586l-2.293-2.293a1 1 0 010-1.414z" clipRule="evenodd" />
                    </svg>
                    </a>
                </div>
                </div>
            </article>
        )
    }
}