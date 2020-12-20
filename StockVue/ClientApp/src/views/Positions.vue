<template>
    <v-container fluid>
        <v-layout column align-center>
            <h1>Positions</h1>
            <!--<StockPosition />-->
        </v-layout>
    </v-container>
</template>

<script lang="ts">
    import { Component, Vue } from 'vue-property-decorator';
    import StockPosition from '@/components/StockPosition.vue'; // @ is an alias to /src    

    @Component({
        //components: {
        //    StockPosition,            
        //},
    })
    export default class StockPositions extends Vue {
        async mounted() {
            console.log("mounted");
            if (this.$store.state.positions.positions.length == 0) {
                this.fetchData()
            }            
        }

        public fetchData(): void {
            this.$store.dispatch("positions/loadStockPositions");
        }
        
    }

</script>
