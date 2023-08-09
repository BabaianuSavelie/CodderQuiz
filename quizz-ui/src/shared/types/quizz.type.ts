import { z } from "zod";
import { CategorySchema } from "./category.type";
import { QuestionSchema } from "./question.type";

export const QuizzSchema = z.object({
  id: z.string().uuid(),
  title: z.string(),
  description: z.string(),
  //   categoryId: z.string().uuid(),
  category: CategorySchema,
  questions: z.array(QuestionSchema),
  createdAt: z.string(),
  updatedAt: z.string(),
});

export type Quizz = z.infer<typeof QuizzSchema>;
