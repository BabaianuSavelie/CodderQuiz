type Props = {
  title: string;
  callToActionText: string;
};

const Banner = (props: Props) => {
  const { title, callToActionText } = props;

  return (
    <div className="container rounded-lg bg-slate-500">
      {title}

      <button className="btn btn-secondary">{callToActionText}</button>
    </div>
  );
};

export default Banner;
