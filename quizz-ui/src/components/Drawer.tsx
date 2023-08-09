import Card from "./Card";
import { FiPlusCircle } from "react-icons/fi";
import { Quizz } from "../shared/types/quizz.type";

type Props = {
  data: Quizz[];
};

const Drawer = (props: Props) => {
  const { data } = props;
  return (
    <div className="drawer lg:drawer-open">
      <input id="my-drawer-2" type="checkbox" className="drawer-toggle" />
      <div className="drawer-content flex flex-col items-center">
        {/* Page content here */}
        <div className="w-full p-3">
          <h1 className="text-4xl font-bold my-4">Quizzes</h1>
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-3">
            {data.map((quizz) => (
              <Card
                key={quizz.id}
                title={quizz.title}
                description={quizz.description}
              />
            ))}
          </div>
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
        <ul className="menu p-4 w-80 h-full bg-base-300 text-base-content">
          {/* Sidebar content here */}
          <li>
            <button className="btn">
              <FiPlusCircle />
              Create
            </button>
          </li>
          <li>
            <a>Sidebar Item 1</a>
          </li>
          <li>
            <a>Sidebar Item 2</a>
          </li>
        </ul>
      </div>
    </div>
  );
};

export default Drawer;
