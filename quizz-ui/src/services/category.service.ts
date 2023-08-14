import { Category, CategorySchema } from "../shared/types/category.type";
import { CategoryRequest } from "../shared/types/requests/category.type";
import { z } from "zod";
import axios from "axios";

type UpdateCategoryProps = {
  id: string;
  category: CategoryRequest;
};

// ! Get All Categories
export const getCategories = async (): Promise<Category[]> => {
  const response = await axios.get("https://localhost:7211/categories");
  console.log(response);
  const categories = z.array(CategorySchema).parse(response.data);

  return categories;
};

// ! Create a new Category
export const createCategory = async (
  category: CategoryRequest
): Promise<CategoryRequest> => {
  const response = await axios.post(
    "https://localhost:7211/categories",
    category
  );
  const newCategory = CategorySchema.parse(response.data);

  return newCategory;
};

// ! Remove a Category
export const deleteCategory = async (id: string) => {
  await axios.delete(`https://localhost:7211/categories/${id}`);
};

// ! Update a Category
export const updateCategory = async ({ id, category }: UpdateCategoryProps) => {
  await axios.put(`https://localhost:7211/categories/${id}`, category);
};
