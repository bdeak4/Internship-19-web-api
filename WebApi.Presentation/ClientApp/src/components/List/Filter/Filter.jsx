import DebouncedInput from "src/components/Input/Debounced";

const Filter = ({ filter, setFilter }) => {
  return (
    <div>
      <DebouncedInput
        placeholder="Search"
        value={filter.title || ""}
        onChange={(title) => setFilter((prev) => ({ ...prev, title }))}
      />
    </div>
  );
};

export default Filter;
