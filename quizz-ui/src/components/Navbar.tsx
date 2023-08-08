import { Link } from "react-router-dom";

type Props = {
  isLoggedIn: boolean;
};

const Navbar = (props: Props) => {
  const { isLoggedIn } = props;
  return (
    <div className="navbar sticky top-0 z-50">
      <div className="flex-1">
        <Link to="/" className="btn btn-ghost normal-case text-xl">
          QuizzyMind
        </Link>
      </div>

      <div className="navbar-end">
        {!isLoggedIn ? (
          <div className="flex gap-2">
            <Link to="/login" className="btn btn-sm btn-outline">
              Login
            </Link>
            <Link to="/signup" className="btn btn-sm btn-primary">
              Sign Up
            </Link>
          </div>
        ) : (
          <div>lofjj</div>
        )}
      </div>
    </div>
  );
};

export default Navbar;
