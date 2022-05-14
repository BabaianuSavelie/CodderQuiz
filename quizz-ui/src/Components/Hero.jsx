import React from "react";
import Image from "../assets/questionsMark.svg";

const Hero = () => {
  return (
    <div className="hero bg-* text-light p-sm-5 text-center text-sm-start">
      <div className="container">
        <div className="row align-items-center">
          <div className="col-12 col-md-6">
            <h1>Open your mind and make the right choice</h1>
            <p className="lead my-3">
              Lorem, ipsum dolor sit amet consectetur adipisicing elit. Esse
              eveniet velit exercitationem nisi placeat molestias, quidem rerum
              fuga cupiditate. Quibusdam?
            </p>
            <button className="btn btn-primary btn-lg">Get started</button>
          </div>
          <div className="col-12 col-md-6">
            <img
              src={Image}
              alt="image"
              className="img-fluid d-none d-sm-block"
            />
          </div>
        </div>
      </div>
    </div>
  );
};

export default Hero;
