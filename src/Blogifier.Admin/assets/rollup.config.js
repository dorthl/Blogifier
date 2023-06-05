import { glob } from 'glob';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import resolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';
import terser from '@rollup/plugin-terser';

export default {
  input: Object.fromEntries(
    glob.sync('js/**/*.js').map(file => [
      // 这里将删除 `src/` 以及每个文件的扩展名。
      // 因此，例如 src/nested/foo.js 会变成 nested/foo
      path.relative(
        'js',
        file.slice(0, file.length - path.extname(file).length)
      ),
      // 这里可以将相对路径扩展为绝对路径，例如
      // src/nested/foo 会变成 /project/src/nested/foo.js
      fileURLToPath(new URL(file, import.meta.url))
    ])
  ),
  output: {
    format: 'es',
    dir: '../wwwroot/admin/js',
    // minifyInternalExports: true,
    // plugins: [terser()]
  },
  plugins: [
    resolve(),
    // commonjs(),
  ]
};