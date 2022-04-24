import DebouncedInput from "src/components/Input/Debounced";

import styles from "./filter.module.scss";

const Filter = ({ filter, setFilter }) => {
  return (
    <div>
      <div className={styles.row}>
        <DebouncedInput
          placeholder="Search"
          value={filter.title || ""}
          onChange={(title) => setFilter((prev) => ({ ...prev, title }))}
        />
        <DebouncedInput
          placeholder="City"
          value={filter.city || ""}
          onChange={(city) => setFilter((prev) => ({ ...prev, city }))}
        />
        <DebouncedInput
          placeholder="County"
          value={filter.county || ""}
          onChange={(county) => setFilter((prev) => ({ ...prev, county }))}
        />
      </div>
      <div className={styles.row}>
        <DebouncedInput
          placeholder="Min Price"
          value={filter.minPrice || ""}
          onChange={(minPrice) => setFilter((prev) => ({ ...prev, minPrice }))}
        />
        <DebouncedInput
          placeholder="Max Price"
          value={filter.maxPrice || ""}
          onChange={(maxPrice) => setFilter((prev) => ({ ...prev, maxPrice }))}
        />
        <select
          className={styles.select}
          onChange={(e) =>
            setFilter((prev) => ({ ...prev, sort: e.target.value }))
          }
        >
          <option value="" selected={!filter.sort}>
            --
          </option>
          <option value="PriceAsc" selected={filter.sort === "PriceAsc"}>
            PriceAsc
          </option>
          <option value="PriceDesc" selected={filter.sort === "PriceDesc"}>
            PriceDesc
          </option>
          <option
            value="CreatedAtAsc"
            selected={filter.sort === "CreatedAtAsc"}
          >
            CreatedAtAsc
          </option>
          <option
            value="CreatedAtDesc"
            selected={filter.sort === "CreatedAtDesc"}
          >
            CreatedAtDesc
          </option>
        </select>
      </div>
    </div>
  );
};

export default Filter;
