import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import App from './App';
import reportWebVitals from './reportWebVitals';
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import ErrorPage from './error-page';
import Home from './routes/home';
import ProfilePage from './routes/profile';
import { library } from '@fortawesome/fontawesome-svg-core'
import { fab } from '@fortawesome/free-brands-svg-icons'
import { fas } from '@fortawesome/free-solid-svg-icons'
import BlogsPage from './routes/blogs';
import LoginPage from './routes/login';
import RegisterPage from './routes/reg';
import CreatePost from './routes/createPost';
import Blog from './routes/blog';
import Search from './routes/search';

library.add(fab, fas)

function Logout(){
  sessionStorage.clear();window.open('/login','_self');return (<></>)
}

const router = createBrowserRouter([
  {
    path: "/",
    element: <App/>,
    ErrorBoundary: ErrorPage,
    children: [
      {
        path: "",
        element: <Home/>
      },
      {
        path: "profile",
        element: <ProfilePage/>
      },
      {
        path: "blogs",
        element: <BlogsPage/>
      },
      {
        path: "login",
        element: <LoginPage/>
      },
      {
        path: 'register',
        element: <RegisterPage/>
      },
      {
        path: 'logout',
        element: <Logout/>
      },
      {
        path: 'create',
        element: <CreatePost />
      },
      {
        path: 'blogs/:blogId',
        element: <Blog />
      },
      {
        path: 'search/:keyword',
        element: <Search />
      }
    ]
  }
]);

const root = ReactDOM.createRoot(document.getElementById('root'));
root.render(
  <React.StrictMode>
    <RouterProvider router={router}/>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
