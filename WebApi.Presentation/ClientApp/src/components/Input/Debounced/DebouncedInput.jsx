import { useMemo, useEffect, useState } from "react";
import debounce from "lodash.debounce";

import Input from "../Input";

const DebouncedInput = (props) => {
  const [value, setValue] = useState(props.value);

  // eslint-disable-next-line
  const debouncedOnChange = useMemo(() => debounce(props.onChange, 500), []);

  useEffect(() => {
    return () => {
      debouncedOnChange.cancel();
    };
    // eslint-disable-next-line
  }, []);

  const onChange = (val) => {
    setValue(val);
    debouncedOnChange(val);
  };

  return <Input {...props} value={value} onChange={onChange} />;
};

export default DebouncedInput;
