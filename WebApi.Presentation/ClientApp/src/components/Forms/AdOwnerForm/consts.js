export const InputName = Object.freeze({
  firstName: "firstName",
  lastName: "lastName",
  phone: "phone",
  email: "email",
});

export const schema = {
  [InputName.firstName]: {
    required: "First name is required",
  },
  [InputName.lastName]: {
    required: "Last name is required",
  },
  [InputName.phone]: {
    required: "Phone is required",
  },
  [InputName.email]: {
    required: "Email is required",
  },
};
