import { Routes, Route, Outlet } from "react-router-dom";
import Navbar from "./components/Navbar";
import Home from "./pages/Home";
import Admin from "./pages/Admin";
import SignUp from "./pages/SignUp";
import Login from "./pages/Login";
import Quizzes from "./pages/Quizzes";
import Categories from "./pages/Categories";

function App() {
  return (
    <>
      {/* Routes with Navbar*/}
      <Routes>
        <Route
          element={
            <>
              <Navbar isLoggedIn={false} />
              <Outlet />
            </>
          }
        >
          <Route path="/" element={<Home />} />
        </Route>

        {/* Routes without navbar*/}
        <Route path="/admin">
          <Route path="dashboard" element={<Admin />}>
            <Route path="quizzes" element={<Quizzes />} />
            <Route path="categories" element={<Categories/>}/>
          </Route>
        </Route>
        <Route path="/signup" element={<SignUp />} />
        <Route path="/login" element={<Login />} />
      </Routes>
    </>
  );
}

export default App;
