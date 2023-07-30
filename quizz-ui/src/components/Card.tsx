type Props = {
  title: string;
  description: string;
};

const Card = (props: Props) => {
  const { title, description } = props;
  return (
    <div className="card w-96 bg-base-100 shadow-xl">
      <div className="card-body">
        <h2 className="card-title">{title}</h2>
        <p>{description}</p>
        <div className="card-actions justify-end">
          <button className="btn btn-primary">Start Quizz</button>
        </div>
      </div>
    </div>
  );
};

export default Card;
