import { FiPlusCircle } from "react-icons/fi";
import { Link, Outlet } from "react-router-dom";
import { TbDeviceImacQuestion } from "react-icons/tb";
import { BiCategoryAlt } from "react-icons/bi";

// type Props = {
//   data: Quizz[];
// };

const Drawer = () => {
  // const { data } = props;
  return (
    <div className="drawer lg:drawer-open">
      <input id="my-drawer-2" type="checkbox" className="drawer-toggle" />
      <div className="drawer-content flex flex-col items-center">
        {/* Page content here */}
        <div className="w-full p-3">
          {/* <h1 className="text-4xl font-bold my-4">Quizzes</h1>
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-3">
            {data.map((quizz) => (
              <Card
                key={quizz.id}
                title={quizz.title}
                description={quizz.description}
              />
            ))}
          </div> */}
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
            <Link to="/admin/dashboard/quizzes" className=" text-lg">
              <TbDeviceImacQuestion />
              Quizzes
            </Link>
          </li>
          <li>
            <Link to="/admin/dashboard/categories" className=" text-lg">
              <BiCategoryAlt />
              Categories
            </Link>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Drawer;
