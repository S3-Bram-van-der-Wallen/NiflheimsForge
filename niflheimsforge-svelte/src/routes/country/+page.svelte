<script lang="ts">
    import { Button } from '@sveltestrap/sveltestrap';
</script>
  
<style>
  body, html {
  height: 100%;
  }
  .flex-container {
  display: flex;
  height: 100vh;
  }
  .country-navigation {
    flex: 0 0 20%;
    background-color: lightgray;
  }
  .country-content {
    flex: 1;
    background-color: gray;
  }
</style>

  <div class="flex-container">
    <div class="country-navigation">
      1
    </div>
    <div class="country-content">
      2
    </div>
    <div style="width: 10px;">
      3
    </div>  
  </div>