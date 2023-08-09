import { z } from "zod";

export const OptionSchema = z.object({
  id: z.string().uuid(),
  label: z.string(),
  isCorrect: z.boolean(),
});

export type Option = z.infer<typeof OptionSchema>;
