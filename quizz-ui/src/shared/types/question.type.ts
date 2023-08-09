import { z } from "zod";
import { OptionSchema } from "./option.type";

export const QuestionSchema = z.object({
  id: z.string().uuid(),
  text: z.string(),
  options: z.array(OptionSchema),
});

export type Question = z.infer<typeof QuestionSchema>;
