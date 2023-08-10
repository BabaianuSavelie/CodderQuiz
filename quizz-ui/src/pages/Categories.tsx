import { Category, CategorySchema } from "../shared/types/category.type";
import { z } from "zod";
import axios from "axios";
import { useQuery } from "react-query";

const Categories = () => {
  const getCategories = async (): Promise<Category[]> => {
    const response = await axios.get("https://localhost:7211/categories");
    console.log(response);
    const categories = z.array(CategorySchema).parse(response.data);

    return categories;
  };

  const { data: categories } = useQuery("categories", getCategories);
  return (
    <div>
      <h1 className="text-4xl font-bold my-4">Categories</h1>
      {/* {categories?.map((category) => (
        <h1 key={category.id}>{category.name}</h1>
      ))} */}
      <div className="overflow-x-auto">
        <table className="table table-zebra w-fit">
          {/* head */}
          <thead>
            <tr>
              <th></th>
              <th>Id</th>
              <th>Name</th>
            </tr>
          </thead>
          <tbody>
            {categories?.map((category, index) => (
              <tr key={category.id}>
                <th>{index + 1}</th>
                <td>{category.id}</td>
                <td>{category.name}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
};

export default Categories;
