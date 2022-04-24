import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";

import ControlledInput from "src/components/Input/Controlled";
import Action from "src/components/Action";
import Loader from "src/components/Loader";

import { useForm } from "react-hook-form";

import { InputName, schema } from "./consts";

import styles from "./ad-form.module.scss";
import { useGetAdCategories } from "src/api/useAdCategory";
import Label from "src/components/Label";

const AdForm = ({
  id,
  title,
  description,
  price,
  city,
  county,
  street,
  categoryId,
  handleRequest,
  error,
  isLoading,
  isSuccessful,
}) => {
  const navigate = useNavigate();
  const {
    handleSubmit,
    control,
    formState: { errors },
    register,
  } = useForm({ mode: "onChange", shouldFocusError: false });
  const {
    data: categoryData,
    error: categoryError,
    isLoading: categoryIsLoading,
  } = useGetAdCategories();

  useEffect(() => {
    if (isSuccessful) {
      setTimeout(() => {
        navigate(id ? `/ads/${id}` : "/ads");
      }, 2000);
    }
  }, [navigate, isSuccessful, id]);

  return (
    <form onSubmit={handleSubmit(handleRequest)} className={styles.form}>
      <ControlledInput
        label="Title"
        inputName={InputName.title}
        rules={schema[InputName.title]}
        defaultValue={title || ""}
        control={control}
        error={errors[InputName.title]}
      />
      <ControlledInput
        label="Description"
        inputName={InputName.description}
        rules={schema[InputName.description]}
        defaultValue={description || ""}
        control={control}
        error={errors[InputName.description]}
      />
      <ControlledInput
        label="Price"
        inputName={InputName.price}
        inputType="number"
        rules={schema[InputName.price]}
        defaultValue={price || 0}
        control={control}
        error={errors[InputName.price]}
      />
      <ControlledInput
        label="City"
        inputName={InputName.city}
        rules={schema[InputName.city]}
        defaultValue={city || ""}
        control={control}
        error={errors[InputName.city]}
      />
      <ControlledInput
        label="County"
        inputName={InputName.county}
        rules={schema[InputName.county]}
        defaultValue={county || ""}
        control={control}
        error={errors[InputName.county]}
      />
      <ControlledInput
        label="Street"
        inputName={InputName.street}
        rules={schema[InputName.street]}
        defaultValue={street || ""}
        control={control}
        error={errors[InputName.street]}
      />

      <div>
        <Label htmlFor="categoryId" text="Category" />
        {!categoryError && !categoryIsLoading && categoryData && (
          <select {...register("categoryId")} className={styles.select}>
            {categoryData.map((category) => (
              <option
                value={category.id}
                key={category.id}
                selected={category.id === categoryId}
              >
                [{category.type}] {category.title}
              </option>
            ))}
          </select>
        )}
      </div>

      <div className={styles.messages}>
        {error && <span className="error">{error}</span>}
        {isSuccessful && <span className="success">Successfully added!</span>}
      </div>

      {!isLoading && (
        <div className={styles.actions}>
          <Action props={{ type: "submit" }} variant="fill">
            Save
          </Action>
        </div>
      )}
      {isLoading && <Loader />}
    </form>
  );
};

export default AdForm;
