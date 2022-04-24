export const InputName = Object.freeze({
  title: "title",
  description: "description",
  price: "price",
  city: "city",
  county: "county",
  street: "street",
});

export const schema = {
  [InputName.title]: {
    required: "Title is required",
  },
  [InputName.description]: {
    required: "Description is required",
  },
  [InputName.price]: {
    required: "Price is required",
  },
  [InputName.city]: {
    required: "City is required",
  },
  [InputName.county]: {
    required: "County is required",
  },
};
