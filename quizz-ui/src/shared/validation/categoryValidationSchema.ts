import { z } from "zod";

export const categoryValidationSchema = z.object({
  name: z.string().min(4).max(20),
});

export type CategoryValidation = z.infer<typeof categoryValidationSchema>;
