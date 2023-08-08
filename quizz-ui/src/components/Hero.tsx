import { BsChevronRight } from "react-icons/bs";
import { Link } from "react-router-dom";
import Line from "../assets/orange_line.svg";
import Image from "../assets/hero_image.png";

const Hero = () => {
  return (
    <div className="hero min-h-screen">
      <div className="hero-content flex-col-reverse text-center">
        <img
          src={Image}
          className="max-w-md rounded-lg hidden md:block my-7"
          alt="Quizz test image"
        />
        <div className="max-w-4xl">
          <h1 className="heading-font text-6xl text-slate-500 font-bold mb-6">
            Expand your Knowledge with
            <span className="text-orange-300 relative ml-3">
              QuizzyMind!
              <img src={Line} className="absolute right-0" alt="" />
            </span>
          </h1>
          <p className="mb-5 text-lg text-center text-gray-400">
            Welcome to QuizzyMind, the app that expands your horizons! Engage
            your intellect with stimulating quizzes, and unlock the power of
            your mind!
          </p>
          <div className="flex flex-col md:flex-row justify-center gap-3">
            <Link
              to="/signup"
              className="btn btn-lg btn-neutral flex-col items-center md:items-start"
            >
              <span className="text-xs">Student</span>
              <span className="flex gap-2">
                Sign Up for free
                <BsChevronRight />
              </span>
            </Link>
            <Link
              to="/signup"
              className="btn btn-lg btn-primary flex-col items-center md:items-start"
            >
              <span className="text-xs">Teacher</span>
              <span className="flex gap-2">
                Sign Up for free
                <BsChevronRight />
              </span>
            </Link>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Hero;
