import { useMutation, useQuery, useQueryClient } from "react-query";
import { AiOutlinePlus } from "react-icons/ai";
import Modal from "../components/Modal";
import {
  CategoryValidation,
  categoryValidationSchema,
} from "../shared/validation/categoryValidationSchema";
import { SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Link, useSearchParams } from "react-router-dom";
import { BiEdit } from "react-icons/bi";
import { RiDeleteBin6Line } from "react-icons/ri";
import { useState } from "react";
import {
  getCategories,
  createCategory,
  deleteCategory,
  updateCategory,
} from "../services/category.service";
import { Category } from "../shared/types/category.type";
import { CategoryRequest } from "../shared/types/requests/category.type";
import axios from "axios";

const Categories = () => {
  const [searchParams, setSearchParams] = useSearchParams();
  const [category, setCategory] = useState<Category | null>(null);

  // const updateCategory = async (id: string, category: CategoryRequest) => {
  //   await axios.put("https://localhost:7211/categories/${id}", category);
  // };

  const queryClient = useQueryClient();

  const { data: categories } = useQuery("categories", getCategories, {
    staleTime: 60000,
  });

  const { mutate: create } = useMutation(createCategory, {
    onSuccess: () => {
      console.log("Added succesfully");
      queryClient.invalidateQueries("categories");
    },
  });

  const { mutate: remove } = useMutation(deleteCategory, {
    onSuccess: () => {
      queryClient.invalidateQueries("categories");
    },
  });

  const update = useMutation(updateCategory, {
    onSuccess: () => {
      queryClient.invalidateQueries("categories");
    },
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm<CategoryValidation>({
    resolver: zodResolver(categoryValidationSchema),
  });

  const onSubmit: SubmitHandler<CategoryValidation> = (data) => create(data);
  const onUpdate: SubmitHandler<CategoryValidation> = (data) => {
    category != null &&
      category &&
      update.mutate({ id: category?.id, category: data });
  };

  return (
    <div>
      <h1 className="text-4xl font-bold my-4">Categories</h1>
      <Link
        to="?showModal=y&mode=create"
        className="btn btn-primary btn-sm mt-5"
      >
        <AiOutlinePlus />
        Add
      </Link>
      <div className="overflow-x-auto">
        <table className="table table-zebra table-pin-rows table-pin-cols">
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
                <td>
                  <div className="flex justify-center gap-2">
                    <button
                      className="btn btn-sm btn-warning"
                      onClick={() => {
                        searchParams.set("showModal", "y");
                        searchParams.append("mode", "edit");
                        setSearchParams(searchParams);
                        setCategory(category);
                      }}
                    >
                      <BiEdit />
                    </button>
                    <button
                      className="btn btn-sm btn-error"
                      onClick={() => remove(category.id)}
                    >
                      <RiDeleteBin6Line />
                    </button>
                  </div>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      {searchParams.get("mode") === "create" ? (
        <Modal title="New Category" onSubmit={handleSubmit(onSubmit)}>
          <div className="form-control w-full my-3 marker:">
            <input
              type="text"
              placeholder="Type here"
              className={`input input-bordered w-full ${
                errors.name && "input-error"
              }`}
              {...register("name")}
            />
            {errors.name && (
              <label className="label">
                <span className="label-text-alt">{errors.name.message}</span>
              </label>
            )}
          </div>
          <div className="flex justify-end gap-2">
            <button className="btn btn-md btn-accent">Create Category</button>
          </div>
        </Modal>
      ) : (
        <Modal title="Update Category" onSubmit={handleSubmit(onUpdate)}>
          <div className="form-control w-full my-3 marker:">
            <input
              type="text"
              placeholder="Type here"
              className={`input input-bordered w-full ${
                errors.name && "input-error"
              }`}
              {...register("name")}
            />
            {errors.name && (
              <label className="label">
                <span className="label-text-alt">{errors.name.message}</span>
              </label>
            )}
          </div>
          <div className="flex justify-end gap-2">
            <button className="btn btn-md btn-accent">Update Category</button>
          </div>
        </Modal>
      )}
    </div>
  );
};

export default Categories;
