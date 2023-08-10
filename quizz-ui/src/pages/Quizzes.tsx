import { z } from "zod";
import axios from "axios";
import { Quizz, QuizzSchema } from "../shared/types/quizz.type";
import Card from "../components/Card";
import { useQuery } from "react-query";

const Quizzes = () => {
  const getQuizzes = async (): Promise<Quizz[]> => {
    const response = await axios.get("https://localhost:7211/quizzes");
    console.log(response);
    const quizzes = z.array(QuizzSchema).parse(response.data);

    return quizzes;
  };

  const { data: quizzes } = useQuery("quizzes", getQuizzes);
  console.log("Quizzes", quizzes);
  return (
    <div>
      <h1 className="text-4xl font-bold my-4">Quizzes</h1>
      <div className="grid grid-cols-1 lg:grid-cols-4 gap-3">
        {quizzes &&
          quizzes.map((quizz) => (
            <Card
              key={quizz.id}
              title={quizz.title}
              description={quizz.description}
            />
          ))}
      </div>
    </div>
  );
};

export default Quizzes;
