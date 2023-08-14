import { z } from "zod";

export const CategoryRequestSchema = z.object({
  name: z.string(),
});

export type CategoryRequest = z.infer<typeof CategoryRequestSchema>;
