import logo from './logo.svg';
import './App.css';
import { Outlet } from 'react-router-dom';

function App() {
  return (
    <>
      <div id="sidebar">
        <h1>CodersHub</h1>
        <div>
            <input
              id="q"
              aria-label="Search CodersHub"
              placeholder="Search CodersHub"
              type="search"
              name="q"
              style={{width: "70%"}}
            />
            <button onClick={()=>window.open('/search/'+document.getElementById('q').value,'_self')}>Search</button>
        </div>
        <nav>
          <ul>
            <li>
              <a href={`/`}>Home</a>
            </li>
            <li>
              <a href={`/blogs`}>Blogs</a>
            </li>
            <li>
              <a href={`/create`}>Create Post</a>
            </li>
            <li>
              <a href={`/profile`}>Profile</a>
            </li>
            <li>
              <a href={`/logout`} style={{color: "red"}}>Log out</a>
            </li>
          </ul>
        </nav>
      </div>
      <div id="childrenElement"><Outlet/></div>
    </>
  );
}

export default App;
