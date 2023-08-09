import axios from "axios";
import Drawer from "../components/Drawer";
import { useQuery } from "react-query";
import { Quizz, QuizzSchema } from "../shared/types/quizz.type";
import { z } from "zod";

const Admin = () => {
  const getQuizzes = async (): Promise<Quizz[]> => {
    const response = await axios.get("https://localhost:7211/quizzes");
    console.log(response);
    const quizzes = z.array(QuizzSchema).parse(response.data);

    return quizzes;
  };

  const { data: quizzes } = useQuery("quizzes", getQuizzes);
  console.log("Quizzes", quizzes);

  return <div>{quizzes && <Drawer data={quizzes} />}</div>;
};

export default Admin;
