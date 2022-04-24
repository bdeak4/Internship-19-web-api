import React, { useEffect } from "react";
import { useNavigate } from "react-router-dom";

import ControlledInput from "src/components/Input/Controlled";
import Action from "src/components/Action";
import Loader from "src/components/Loader";

import { useForm } from "react-hook-form";

import { InputName, schema } from "./consts";

import styles from "./ad-owner-form.module.scss";

const AdForm = ({
  id,
  firstName,
  lastName,
  phone,
  email,
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
  } = useForm({ mode: "onChange", shouldFocusError: false });

  useEffect(() => {
    if (isSuccessful) {
      setTimeout(() => {
        navigate("/ads");
      }, 2000);
    }
  }, [navigate, isSuccessful, id]);

  return (
    <form onSubmit={handleSubmit(handleRequest)} className={styles.form}>
      <ControlledInput
        label="First Name"
        inputName={InputName.firstName}
        rules={schema[InputName.firstName]}
        defaultValue={firstName || ""}
        control={control}
        error={errors[InputName.firstName]}
      />
      <ControlledInput
        label="Last Name"
        inputName={InputName.lastName}
        rules={schema[InputName.lastName]}
        defaultValue={lastName || ""}
        control={control}
        error={errors[InputName.lastName]}
      />
      <ControlledInput
        label="Email"
        inputName={InputName.email}
        rules={schema[InputName.email]}
        defaultValue={email || ""}
        control={control}
        error={errors[InputName.email]}
      />
      <ControlledInput
        label="Phone"
        inputName={InputName.phone}
        rules={schema[InputName.phone]}
        defaultValue={phone || ""}
        control={control}
        error={errors[InputName.phone]}
      />
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
