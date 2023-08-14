import { FiPlusCircle } from "react-icons/fi";
import { NavLink, Outlet } from "react-router-dom";
import { TbDeviceImacQuestion } from "react-icons/tb";
import { BiCategoryAlt } from "react-icons/bi";

const Drawer = () => {
  return (
    <div className="drawer lg:drawer-open">
      <input id="my-drawer-2" type="checkbox" className="drawer-toggle" />
      <div className="drawer-content flex flex-col items-center">
        {/* Page content here */}
        <div className="w-full p-3">
          <Outlet />
        </div>
        <label
          htmlFor="my-drawer-2"
          className="btn btn-primary drawer-button lg:hidden"
        >
          Open drawer
        </label>
      </div>
      <div className="drawer-side">
        <label htmlFor="my-drawer-2" className="drawer-overlay"></label>
        <ul className="menu p-4 w-80 h-full bg-base-300 text-base-content justify-center">
          {/* Sidebar content here */}
          <button className="btn btn-primary text-lg">
            <FiPlusCircle />
            Create
          </button>
          <div className="divider"></div>
          <li className="my-2">
            <NavLink to="quizzes" className=" text-lg">
              <TbDeviceImacQuestion />
              Quizzes
            </NavLink>
          </li>
          <li>
            <NavLink to="categories" className=" text-lg">
              <BiCategoryAlt />
              Categories
            </NavLink>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Drawer;
