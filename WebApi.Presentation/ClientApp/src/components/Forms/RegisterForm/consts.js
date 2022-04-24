export const InputName = Object.freeze({
  email: "email",
  password: "password",
  repeatPassword: "repeatPassword",
});

export const schema = {
  [InputName.email]: {
    required: "Email is required",
  },
  [InputName.password]: {
    required: "Password is required",
    minLength: {
      value: 6,
      message: "Password must have at least 6 letters/digits",
    },
  },
};
