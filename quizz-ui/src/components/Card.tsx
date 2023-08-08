import { FaPlay } from "react-icons/fa";

type Props = {
  title: string;
  description: string;
};

const Card = (props: Props) => {
  const { title, description } = props;
  return (
    <div className="card w-full bg-base-200 shadow-lg shadow-neutral-900">
      <div className="card-body">
        <h2 className="card-title">{title}</h2>
        <p className="text-sm line-clamp-1">{description}</p>
        <div className="card-actions justify-end">
          <button className="btn btn-primary btn-sm">
            <FaPlay />
            Start Quizz
          </button>
        </div>
      </div>
    </div>
  );
};

export default Card;
